import React, { useEffect, useState } from "react";
import "antd/dist/antd.css";
import "./thread-window.styles.css";
import { Layout } from "antd";
import MessageCard from "../message-card/message-card.component";

const { Content } = Layout;

const ThreadWindow = ({ selectedRoom, onReply }) => {
  const [threads, setThreads] = useState(null);
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

  return (
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
              id={thread.id}
              content={thread.content}
              onReply={(threadId) => onReply(threadId)}
            ></MessageCard>
          ))}
      </div>
    </Content>
  );
};

export default ThreadWindow;
