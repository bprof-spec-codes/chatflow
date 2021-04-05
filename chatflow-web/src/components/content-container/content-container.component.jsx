import React, { useEffect, useState } from "react";
import "antd/dist/antd.css";
import "./content-container.styles.css";
import { Layout } from "antd";
import { Demo } from "../comment/comment.component";

const { Content } = Layout;

export const ContentContainer = ({ selectedRoom }) => {
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
      {threads &&
        threads.map((thread) => <Demo content={thread.content}></Demo>)}
      {/* <Demo></Demo>
      <Demo></Demo>
      <Demo></Demo>
      <Demo></Demo>
      <Demo></Demo>
      <Demo></Demo>
      <Demo></Demo>
      <Demo></Demo>
      <Demo></Demo> */}
    </Content>
  );
};
