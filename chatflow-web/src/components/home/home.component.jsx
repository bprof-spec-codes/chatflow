import React, { useEffect, useState } from "react";
import "./home.styles.css";
import { Layout } from "antd";
import { Sidebar } from "../side-bar/side-bar.component";
import { TopRow } from "../header/header.component";
import { ContentContainer } from "../content-container/content-container.component";
import { useParams } from "react-router";

export const Home = () => {
  const [loading, setLoading] = useState(false);
  const [rooms, setRooms] = useState(null);
  const [selectedRoom, setSelectedRoom] = useState(null);
  const {id} = useParams();

  useEffect(() => {
    setLoading(true);
    const minTime = new Promise((resolve) => setTimeout(resolve, 2000));
    const req = fetch("/api/channels").then((res) => res.json());

    Promise.all([minTime, req]).then((values) => {
      const reqData = values[1];
      setRooms(reqData);
      setLoading(false);
    });
  }, []);

  useEffect(() => {
      if (rooms) {
        setSelectedRoom(id ? rooms.find(c => c.id === Number(id)) : rooms[0]);
      }
  }, [id, rooms])

  return (
    <div className="Home">
      <Layout style={{ minHeight: "100vh" }}>
        <Sidebar loading={loading} rooms={rooms}></Sidebar>
        <Layout className="site-layout">
          <TopRow selectedRoom={selectedRoom}></TopRow>
          <ContentContainer></ContentContainer>
        </Layout>
      </Layout>
    </div>
  );
};
