import React, { useEffect, useState } from "react";
import "antd/dist/antd.css";
import "./thread-window.styles.css";
import Editor from "../editor/editor.component";
import MessageList from "./message-list.component";
import TopRow from "../header/header.component";
import { ChatWindow } from "../chat-window/chat-window.component";

const ThreadWindow = ({
  selectedRoom,
  onReply,
  selectedThreadId,
  setSelectedThreadId,
}) => {
  const [threads, setThreads] = useState(null);
  const [loading, setLoading] = useState(true);
  const users = ["Valaki", "Valami"];

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

  const addThread = (content) => {
    //TODO: implement api
    if (threads) {
      setThreads((threads) => threads.concat({ id: 1111, content }));
    } else {
      setThreads([{ id: 1111, content }]);
    }
  };

  const pinThread = (id, pinned) => {
    fetch(`/api/Thread/${id}`, {
      headers: { "Content-Type": "application/json" },
      method: "PUT",
      body: JSON.stringify({ pinned }),
    }).then(() =>
      setThreads((threads) =>
        threads.map((thread) =>
          thread.id === id ? { ...thread, pinned } : thread
        )
      )
    );
  };

  return (
    <div className="main-window">
      <TopRow
        selectedRoom={selectedRoom}
        pinnedThreads={threads ? threads.filter((t) => t.pinned) : ""}
      ></TopRow>
      <div className="row">
        <div className="thread-window">
          <MessageList
            loading={loading}
            messages={threads}
            onReply={onReply}
            onPin={pinThread}
          />
          <div className="write-post">
            <Editor
              users={users}
              shouldClear={loading}
              onSend={(content) => addThread(content)}
            />
          </div>
        </div>
        {selectedThreadId && (
          <ChatWindow
            threadId={selectedThreadId}
            onClose={() => setSelectedThreadId(null)}
          />
        )}
      </div>
    </div>
  );
};

export default ThreadWindow;
