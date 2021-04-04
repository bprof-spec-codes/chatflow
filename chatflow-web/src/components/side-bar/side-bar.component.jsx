import React from "react";
import "antd/dist/antd.css";
import "./side-bar.styles.css";
import { Menu, Layout, Skeleton } from "antd";
import { Link } from "react-router-dom";

const { Sider } = Layout;

export const Sidebar = (props) => {
  const { loading, rooms } = props;

  return (
    <Sider className="side-bar">
      <div className="logo">ChatFlow</div>
      <Skeleton
        loading={loading}
        active
        title={false}
        paragraph={{ rows: 5 }}
      />
      {rooms && (
        <Menu theme="dark">
          {rooms.map((room) => (
            <Menu.Item key={room.id}>
              <Link to={`/rooms/${room.id}`}>{room.name}</Link>
            </Menu.Item>
          ))}
        </Menu>
      )}
    </Sider>
  );
};
