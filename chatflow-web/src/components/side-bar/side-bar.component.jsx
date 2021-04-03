import React, { useEffect, useState } from "react";
import "antd/dist/antd.css";
import "./side-bar.styles.css";
import { Menu, Layout, Skeleton } from "antd";
import { Link } from "react-router-dom";

const { Sider } = Layout;

export const Sidebar = (props) => {
  const [loading, setLoading] = useState(false);
  const [channels, setChannels] = useState(null);

  useEffect(() => {
    setLoading(true);
    const minTime = new Promise(resolve => setTimeout(resolve, 2000))
    const req = fetch("/api/channels").then(res => res.json())
    Promise.all([minTime, req]).then(values => {
      const reqData = values[1]
      setChannels(reqData)
      setLoading(false);
    })
  }, []);

  return (
    <Sider className="side-bar">
      <div className="logo">ChatFlow</div>
      <Skeleton loading={loading} active title={false} paragraph={{rows: 5}}/>
      {channels && (
          <Menu theme="dark">
            {channels.map(channel => (
              <Menu.Item key={channel.id}>
                <Link to={`/channels/${channel.id}`}>{channel.name}</Link>
              </Menu.Item>
            ))}
          </Menu>
        )}
    </Sider>
  );
};
