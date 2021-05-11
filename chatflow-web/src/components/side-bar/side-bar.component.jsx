import React, { useState } from "react";
import "antd/dist/antd.css";
import "./side-bar.styles.css";
import { Menu, Layout, Skeleton } from "antd";
import { Link } from "react-router-dom";
import jwt_decode from "jwt-decode";
import Cookies from "js-cookie";

const { Sider } = Layout;

export const Sidebar = (props) => {
  const { loading, rooms } = props;
  const [isAdmin, setIsAdmin] = useState(false);
  const token = Cookies.get("auth");
  const decoded = jwt_decode(token);

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
            <Menu.Item key={room.roomID}>
              <Link to={`/room/${room.roomID}`}>{"# " + room.roomName}</Link>
            </Menu.Item>
          ))}
        </Menu>
      )}
    </Sider>
  );
};
