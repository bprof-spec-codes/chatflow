import React from "react";
import "antd/dist/antd.css";
import "./header.styles.css";
import { Layout, Avatar, Skeleton, Menu, Dropdown, Button } from "antd";
import { UserOutlined, PushpinOutlined } from "@ant-design/icons";
import MessageCard from "../message-card/message-card.component";

const { Header } = Layout;

const menu = (
  <Menu>
    <Menu.Item key="0">
      <a href="https://www.antgroup.com">1st menu item</a>
    </Menu.Item>
    <Menu.Item key="1">
      <a href="https://www.aliyun.com">2nd menu item</a>
    </Menu.Item>
    <Menu.Divider />
    <Menu.Item key="3">
      <MessageCard></MessageCard>
    </Menu.Item>
  </Menu>
);

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
      <Dropdown overlay={menu} trigger={["click"]} placement="bottomRight">
        <Button icon={<PushpinOutlined />}></Button>
      </Dropdown>
      <div className="header-right-avatar">
        <Avatar size="large" icon={<UserOutlined />} />
      </div>
    </div>
  </Header>
);
