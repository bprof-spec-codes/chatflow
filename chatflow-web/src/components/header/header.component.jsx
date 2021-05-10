import React from "react";
import "antd/dist/antd.css";
import "./header.styles.css";
import { Layout, Avatar, Skeleton, Dropdown, Button } from "antd";
import { UserOutlined, PushpinOutlined } from "@ant-design/icons";
import MessageList from "../thread-window/message-list.component";

const { Header } = Layout;

const TopRow = ({ selectedRoom, pinnedThreads }) => (
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
      <div className="dropdown">
        <Dropdown
          overlay={
            <div className="dropdown-messages">
              <MessageList messages={pinnedThreads} />
            </div>
          }
          trigger={["click"]}
          placement="bottomRight"
        >
          <Button icon={<PushpinOutlined />} type="primary"></Button>
        </Dropdown>
      </div>
      <div className="header-right-avatar">
        <Avatar size="large" icon={<UserOutlined />} />
      </div>
    </div>
  </Header>
);

export default TopRow;
