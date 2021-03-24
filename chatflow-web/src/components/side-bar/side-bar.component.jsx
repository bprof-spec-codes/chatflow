import React from "react";
import "antd/dist/antd.css";
import "./side-bar.styles.css";
import { Menu, Layout } from "antd";
import { Link } from "react-router-dom";

const { Sider } = Layout;

export const Sidebar = (props) => (
  <Sider className="side-bar">
    <div className="logo">ChatFlow</div>
    <Menu theme="dark">
      <Menu.Item key="1">
        {/* <Link to="/channel1">Channel 1</Link> */}
        Channel 1
      </Menu.Item>
      <Menu.Item key="2">
        {/* <Link to="/channel2">Channel 2</Link> */}
        Channel 2
      </Menu.Item>
      <Menu.Item key="3">
        {/* <Link to="/channel3">Channel 3</Link> */}
        Channel 3
      </Menu.Item>
    </Menu>
  </Sider>
);
