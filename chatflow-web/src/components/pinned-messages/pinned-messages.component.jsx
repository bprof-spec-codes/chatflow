import React from "react";
import { Menu } from "antd";
import MessageCard from "../message-card/message-card.component";
import "./pinned-messages.styles.css";

export const PinnedMessages = ({ selectedRoom }) => (
  <Menu>
    <div className="pinned__title">
      <h2>Pinned Messages</h2>
    </div>
    {selectedRoom.threads &&
      selectedRoom.threads.map((thread) =>
        thread.pinned === true ? (
          <Menu.Item key={thread.id}>
            <MessageCard
              key={thread.id}
              id={thread.id}
              pinned={thread.pinned}
              content={thread.content}
            ></MessageCard>
          </Menu.Item>
        ) : null
      )}
  </Menu>
);
