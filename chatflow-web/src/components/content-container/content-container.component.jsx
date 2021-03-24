import React from "react";
import "antd/dist/antd.css";
import "./content-container.styles.css";
import { Layout } from "antd";

const { Content } = Layout;

export const ContentContainer = (props) => (
  <Content className="content-container">
    <div className="site-layout-background">Placeholder</div>
  </Content>
);
