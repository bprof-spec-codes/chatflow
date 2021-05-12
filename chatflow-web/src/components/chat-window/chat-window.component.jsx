import React, { useEffect, useState } from "react";
import "./chat-window.styles.css";
import Editor from "../editor/editor.component";
import { Button } from "antd";
import { CloseOutlined } from "@ant-design/icons";
import MessageList from "../thread-window/message-list.component";

export const ChatWindow = ({ threadId, onClose }) => {
  const [messages, setMessages] = useState(null);
  const [loading, setLoading] = useState(true);
  const users = ["Valaki", "Valami"];

  const axios = require("axios");

  useEffect(() => {
    if (threadId) {
      setLoading(true);
      setMessages(null);
      const minTime = new Promise((resolve) => setTimeout(resolve, 1000));
      //const req = fetch(`/threads/Room/${threadId}`).then((res) => res.json());
      const req = axios.get(`/messages/${threadId}`);

      Promise.all([minTime, req])
        .then((values) => {
          const reqData = values[1];
          //console.log(reqData.data);
          setMessages(reqData.data);
          setLoading(false);
        })
        .catch((err) => {
          console.error(err);
          setLoading(false);
        });
    }
  }, [threadId, axios]);

  const addMessage = (content, name) => {
    //TODO: implement api
    /*if (messages) {
      setMessages((messages) => messages.concat({ id: 1111, content, name }));
    } else {
      setMessages([{ id: 1111, content, name }]);
    }*/

    axios
      .post(`/messages/${threadId}`, { content: content, senderName: name })
      .then(() =>
        axios.get(`/messages/${threadId}`).then((res) => setMessages(res.data))
      );
  };

  return (
    <div className="chat-window">
      <div className="chat-window__title">
        <h2>Thread</h2>
        <Button type="text" icon={<CloseOutlined />} onClick={onClose}></Button>
      </div>
      <MessageList loading={loading} messages={messages} />
      <Editor
        users={users}
        onSend={(content) => addMessage(content)}
        shouldClear={loading}
      />
    </div>
  );
};
