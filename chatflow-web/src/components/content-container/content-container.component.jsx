import React, { useEffect } from "react";
import "antd/dist/antd.css";
import "./content-container.styles.css";
import { Layout } from "antd";
import { Demo } from "../comment/comment.component";

const { Content } = Layout;

export const ContentContainer = (props) => {
  useEffect(() => {
    const messageBody = document.getElementById("messagebody");
    messageBody.scrollTop = messageBody.scrollHeight;

  }, []);

  return (
    <Content className="content-container" id="messagebody">
      <Demo></Demo>
      <Demo></Demo>
      <Demo></Demo>
      <Demo></Demo>
      <Demo></Demo>
      <Demo></Demo>
      <Demo></Demo>
      <Demo></Demo>
      <Demo></Demo>
    </Content>
  );
};
