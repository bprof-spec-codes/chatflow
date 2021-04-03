import React from "react";
import "antd/dist/antd.css";
import "./header.styles.css";
import { Layout, Avatar } from "antd";
import { UserOutlined } from "@ant-design/icons";

const { Header } = Layout;

export const TopRow = (props) => (
  <Header className="header">
    <div className="header-left">{props.id}</div>
    <div className="header-right">
      <Avatar size="large" icon={<UserOutlined />} />
    </div>
  </Header>
);
