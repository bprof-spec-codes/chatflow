import React, { useEffect, useState } from "react";
import "./home.styles.css";
import { Layout } from "antd";
import { Sidebar } from "../side-bar/side-bar.component";
import { TopRow } from "../header/header.component";
import ThreadWindow from "../thread-window/thread-window.component";
import { useParams } from "react-router";
import { ChatWindow } from "../chat-window/chat-window.component";

export const Home = () => {
  const [loading, setLoading] = useState(false);
  const [rooms, setRooms] = useState(null);
  const [selectedRoom, setSelectedRoom] = useState(null);
  const [selectedThread, setSelectedThread] = useState(null);
  const { id } = useParams();

  useEffect(() => {
    setLoading(true);
    const minTime = new Promise((resolve) => setTimeout(resolve, 1500));
    const req = fetch("/api/Room").then((res) => res.json());

    Promise.all([minTime, req]).then((values) => {
      const reqData = values[1];
      setRooms(reqData);
      setLoading(false);
    });
  }, []);

  useEffect(() => {
    if (rooms) {
      setSelectedRoom(id ? rooms.find((c) => c.id === Number(id)) : rooms[0]);
      setSelectedThread(null);
    }
  }, [id, rooms]);

  return (
    <div className="Home">
      <Layout style={{ minHeight: "100vh" }}>
        <Sidebar loading={loading} rooms={rooms}></Sidebar>
        <Layout className="site-layout">
          <TopRow selectedRoom={selectedRoom}></TopRow>
          <div style={{ display: "flex" }}>
            <div style={{ width: "100%" }}>
              <ThreadWindow
                selectedRoom={selectedRoom}
                onReply={(threadId) => setSelectedThread(threadId)}
              ></ThreadWindow>
            </div>
            {selectedThread && (
              <ChatWindow
                threadId={selectedThread}
                onClose={() => setSelectedThread(null)}
              />
            )}
          </div>
        </Layout>
      </Layout>
    </div>
  );
};
