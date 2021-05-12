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

  const axios = require("axios");

  useEffect(() => {
    if (selectedRoom) {
      setLoading(true);
      setThreads(null);
      const minTime = new Promise((resolve) => setTimeout(resolve), 100);
      const req = axios.get(`/threads/Room/${selectedRoom.roomID}`);

      Promise.all([minTime, req]).then((values) => {
        const reqData = values[1];
        setThreads(reqData.data);
        setLoading(false);
      });
    }
  }, [axios, selectedRoom]);

  const addThread = (content, name) => {
    //TODO: implement api
    /*if (threads) {
      setThreads((threads) => threads.concat({ id: 1111, content, name }));
    } else {
      setThreads([{ id: 1111, content, name }]);
    }*/
    axios
      .post(`/room/${selectedRoom.roomID}`, {
        content: content,
        senderName: name,
      })
      .then(() =>
        axios
          .get(`/threads/Room/${selectedRoom.roomID}`)
          .then((res) => setThreads(res.data))
      );
  };

  const pinThread = (id, pinned) => {
    if (pinned) {
      axios
        .put(`/threads/DeletePin/${id}`)
        .then(() =>
          setThreads((threads) =>
            threads.map((thread) =>
              thread.threadID === id ? { ...thread, isPinned: false } : thread
            )
          )
        );
    }
    if (!pinned) {
      axios.put(`/threads/Pin/${id}`).then((res) => {
        if (res.data === "SUCCESS") {
          setThreads((threads) =>
            threads.map((thread) =>
              thread.threadID === id ? { ...thread, isPinned: true } : thread
            )
          );
        }
      });
    }
  };

  return (
    <div className="main-window">
      <TopRow
        selectedRoom={selectedRoom}
        pinnedThreads={threads ? threads.filter((t) => t.isPinned) : ""}
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
