import React, { useEffect, useState } from "react";
import "antd/dist/antd.css";
import "./thread-window.styles.css";
import { Layout } from "antd";
import MessageCard from "../message-card/message-card.component";
import Editor from "../editor/editor.component";
const { Content } = Layout;

const ThreadWindow = ({ selectedRoom, onReply }) => {
  const [threads, setThreads] = useState(null);
  const users = ["Valaki", "Valami"];
  // const { room } = props;

  useEffect(() => {
    if (selectedRoom) {
      fetch(`/api/Room/${selectedRoom.id}`)
        .then((res) => res.json())
        .then((room) => setThreads(room.threads));
    }
  }, [selectedRoom]);

  useEffect(() => {
    const messageBody = document.getElementById("messagebody");
    messageBody.scrollTop = messageBody.scrollHeight;
  }, [threads]);

  const addThread = (content) => {
    //TODO: implement api
    setThreads((threads) => threads.concat({ id: 1111, content: content }));
  };

  return (
    <div className="thread-window">
      <Content className="content-container" id="messagebody">
        <div>
          {!threads && (
            <div>
              <MessageCard></MessageCard>
              <MessageCard></MessageCard>
              <MessageCard></MessageCard>
            </div>
          )}
          {threads &&
            threads.map((thread) => (
              <MessageCard
                key={thread.id}
                id={thread.id}
                content={thread.content}
                onReply={(threadId) => onReply(threadId)}
              ></MessageCard>
            ))}
        </div>
      </Content>
      <div className="write-post">
        <Editor users={users} onSend={(content) => addThread(content)} />
      </div>
    </div>
  );
};

export default ThreadWindow;
