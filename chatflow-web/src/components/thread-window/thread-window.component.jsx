import React, { useEffect, useState } from "react";
import "antd/dist/antd.css";
import "./thread-window.styles.css";
import { Layout, Empty } from "antd";
import MessageCard from "../message-card/message-card.component";
import Editor from "../editor/editor.component";
const { Content } = Layout;

const ThreadWindow = ({ selectedRoom, onReply }) => {
  const [threads, setThreads] = useState(null);
  const [loading, setLoading] = useState(true);
  const users = ["Valaki", "Valami"];
  // const { room } = props;

  useEffect(() => {
    if (selectedRoom) {
      setLoading(true);
      setThreads(null);
      const minTime = new Promise((resolve) => setTimeout(resolve, 200));
      const req = fetch(`/api/Room/${selectedRoom.id}`).then((res) =>
        res.json()
      );

      Promise.all([minTime, req]).then((values) => {
        const reqData = values[1];
        setThreads(reqData.threads);
        setLoading(false);
      });
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
      <Content className="content" id="messagebody">
        <div>
          {loading && (
            <div>
              <MessageCard></MessageCard>
              <MessageCard></MessageCard>
              <MessageCard></MessageCard>
            </div>
          )}
          {!loading && !threads && <Empty description="No messages yet!" />}
          {!loading &&
            threads &&
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
        <Editor
          users={users}
          shouldClear={loading}
          onSend={(content) => addThread(content)}
        />
      </div>
    </div>
  );
};

export default ThreadWindow;
