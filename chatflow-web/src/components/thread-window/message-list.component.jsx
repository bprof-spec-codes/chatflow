import React, { useRef, useEffect } from "react";
import MessageCard from "../message-card/message-card.component";
import { Empty } from "antd";

const MessageList = ({ loading, messages, onReply, onPin }) => {
  const messageList = useRef();

  useEffect(() => {
    messageList.current.scrollTop = messageList.current.scrollHeight;
  }, [messages, loading]);

  return (
    <div className="message-list" ref={messageList}>
      {loading && (
        <div>
          <MessageCard></MessageCard>
          <MessageCard></MessageCard>
          <MessageCard></MessageCard>
        </div>
      )}
      {!loading && messages.length === 0 && (
        <Empty description="No messages yet!" />
      )}
      {!loading &&
        messages &&
        messages.map((message) => (
          <MessageCard
            key={message.threadID}
            id={message.threadID}
            pinned={message.isPinned}
            content={message.content}
            onReply={onReply}
            onPin={onPin}
          ></MessageCard>
        ))}
    </div>
  );
};

export default MessageList;
