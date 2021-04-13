import React from "react";
import "antd/dist/antd.css";
import "./header.styles.css";
import { Layout, Avatar, Skeleton } from "antd";
import { UserOutlined } from "@ant-design/icons";

const { Header } = Layout;

export const TopRow = ({ selectedRoom }) => (
  <Header className="header">
    <div className="header-left">
      <Skeleton
        loading={!selectedRoom}
        active
        title={false}
        paragraph={{ rows: 1 }}
      />
      {selectedRoom ? <h3>{selectedRoom.name}</h3> : ""}
    </div>
    <div className="header-right">
      <Avatar size="large" icon={<UserOutlined />} />
    </div>
  </Header>
);
