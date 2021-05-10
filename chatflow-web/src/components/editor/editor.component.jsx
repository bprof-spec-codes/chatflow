import React from "react";
import ContentEditable from "react-contenteditable";
import { SendOutlined } from "@ant-design/icons";
import { Button } from "antd";
import "./editor.styles.css";

const UserList = ({ users, onSelect, selectedUser }) => {
  if (!users || users.length === 0) {
    return (
      <div className="user-list">
        <span>No such user</span>
      </div>
    );
  }

  return (
    <div className="user-list">
      {users.map((user, i) => (
        <div
          key={user}
          className={
            i === selectedUser ? "user-item user-item--selected" : "user-item"
          }
          onClick={() => onSelect(user)}
        >
          <span>@{user}</span>
        </div>
      ))}
    </div>
  );
};

/**
 * This had to be a class component because a function component's state created by the useState hook can not be used in events like onKeyDown.
 * That's because the event listener will only see the initial state and not the changes.
 * It can be solved by creating a ref with useRef and storing the state in it on every change, like this:
 * {@link https://medium.com/geographit/accessing-react-state-in-event-listeners-with-usestate-and-useref-hooks-8cceee73c559}
 * But using a class component seemed to be easier and prettier.
 */
class Editor extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      text: props.initialText || "",
      usersDisplayed: false,
      filteredUsers: [],
      selectedUser: 0,
    };
  }

  static getDerivedStateFromProps(nextProps, prevState) {
    if (nextProps.shouldClear) {
      return {
        text: "",
      };
    }
    return null;
  }

  getActiveTag(text) {
    const tagging = /@\w+/;
    const alreadyATag = /<span.*user-tag.*span>/;

    const removedTags = text.replace(alreadyATag, "");
    const res = removedTags.match(tagging);
    return res ? res[0] : null;
  }

  handleChange(e) {
    const value = e.target.value;

    const activeTag = this.getActiveTag(value);
    if (activeTag) {
      const filter = activeTag.slice(1).toLowerCase();
      const list = this.props.users
        .filter((u) => u.toLowerCase().startsWith(filter))
        .sort();
      this.setState({
        filteredUsers: list,
        usersDisplayed: true,
      });
    } else if (this.state.usersDisplayed) {
      this.setState({
        filteredUsers: [],
        usersDisplayed: false,
      });
    }

    this.setState({
      text: value,
    });
  }

  handleKeyDown(e) {
    const ARROW_UP = 38;
    const ARROW_DOWN = 40;
    const ENTER = 13;

    if (e.keyCode === ARROW_UP && this.state.usersDisplayed) {
      e.preventDefault();
      this.setState((prevState) => ({
        selectedUser:
          prevState.selectedUser === 0
            ? prevState.filteredUsers.length - 1
            : prevState.selectedUser - 1,
      }));
    } else if (e.keyCode === ARROW_DOWN && this.state.usersDisplayed) {
      e.preventDefault();
      this.setState((prevState) => ({
        selectedUser:
          prevState.selectedUser === prevState.filteredUsers.length - 1
            ? 0
            : prevState.selectedUser + 1,
      }));
    } else if (e.keyCode === ENTER && this.state.usersDisplayed) {
      e.preventDefault();
      this.addTag(this.state.filteredUsers[this.state.selectedUser]);
    } else if (
      e.keyCode === ENTER &&
      !e.shiftKey &&
      !this.state.usersDisplayed
    ) {
      e.preventDefault();
      this.props.onSend(this.state.text);
      this.setState({
        text: "",
      });
    }
  }

  addTag(userName) {
    const activeTag = this.getActiveTag(this.state.text);
    this.setState((prevState) => ({
      text: prevState.text.replace(
        activeTag,
        `<span class='user-tag' contentEditable='false'>@${userName}</span>`
      ),
      usersDisplayed: false,
      selectedUser: 0,
    }));
  }

  render() {
    const { usersDisplayed, filteredUsers, selectedUser, text } = this.state;

    return (
      <div className="editor">
        <div className="editor-input">
          {usersDisplayed && (
            <UserList
              users={filteredUsers}
              onSelect={this.addTag.bind(this)}
              selectedUser={selectedUser}
            />
          )}
          <ContentEditable
            html={text}
            onChange={this.handleChange.bind(this)}
            onKeyDown={this.handleKeyDown.bind(this)}
            data-placeholder="Type your message..."
          />
        </div>
        {text && (
          <div className="send-container ">
            <Button
              icon={<SendOutlined />}
              type="primary"
              onClick={() => this.props.onSend(text)}
            />
          </div>
        )}
      </div>
    );
  }
}

export default Editor;
