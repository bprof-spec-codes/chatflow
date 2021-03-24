import React from "react";
import "antd/dist/antd.css";
import "./content-container.styles.css";
import { Layout } from "antd";
import { Demo } from "../comment/comment.component";

const { Content } = Layout;

export const ContentContainer = (props) => (
  <Content className="content-container">
    <div className="box">
      <Demo></Demo>
    </div>
    <div className="box">
      <Demo></Demo>
    </div>
    <div className="box">
      <Demo></Demo>
    </div>
    <div className="box">
      <Demo></Demo>
    </div>
    <div className="box">
      <Demo></Demo>
    </div>
    <div className="box">
      <Demo></Demo>
    </div>
    <div className="box">
      <Demo></Demo>
    </div>
    <div className="box">
      <Demo></Demo>
    </div>
    <div className="box">
      <Demo></Demo>
    </div>
  </Content>
);
