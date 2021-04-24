import React, { useEffect, useState } from "react";
import "./chat-window.styles.css";
import Editor from "../editor/editor.component";
import MessageCard from "../message-card/message-card.component";
import { Empty, Button } from "antd";
import { CloseOutlined } from "@ant-design/icons";

export const ChatWindow = ({ threadId, onClose }) => {
  const [messages, setMessages] = useState(null);
  const [loading, setLoading] = useState(true);
  const users = ["Valaki", "Valami"];

  useEffect(() => {
    if (threadId) {
      setLoading(true);
      setMessages(null);
      const minTime = new Promise((resolve) => setTimeout(resolve, 1000));
      const req = fetch(`/api/Thread/${threadId}`).then((res) => res.json());

      Promise.all([minTime, req])
        .then((values) => {
          const reqData = values[1];
          setMessages(reqData.messages);
          setLoading(false);
        })
        .catch((err) => {
          console.error(err);
          setLoading(false);
        });
    }
  }, [threadId]);

  useEffect(() => {
    const chatWindow = document.querySelector(".chat-window__content");
    chatWindow.scrollTop = chatWindow.scrollHeight;
  }, [messages]);

  const addMessage = (content) => {
    //TODO: implement api
    if (messages) {
      setMessages((messages) =>
        messages.concat({ id: 1111, content })
      );
    }else{
      setMessages([{ id: 1111, content }]);
    }
  };

  return (
    <div className="chat-window">
      <div className="chat-window__title">
        <h2>Thread</h2>
        <Button type="text" icon={<CloseOutlined />} onClick={onClose}></Button>
      </div>
      <div className="chat-window__content">
        {loading && (
          <div>
            <MessageCard></MessageCard>
            <MessageCard></MessageCard>
            <MessageCard></MessageCard>
          </div>
        )}
        {!messages && !loading && <Empty description="No messages yet!" />}
        {messages &&
          !loading &&
          messages.map((message) => (
            <MessageCard
              key={message.id}
              id={message.id}
              content={message.content}
            ></MessageCard>
          ))}
      </div>
      <Editor
        users={users}
        onSend={(content) => addMessage(content)}
        shouldClear={loading}
      />
    </div>
  );
};
