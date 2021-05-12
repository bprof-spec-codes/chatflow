import React, { useRef, useEffect } from "react";
import MessageCard from "../message-card/message-card.component";
import { Empty } from "antd";

const MessageList = ({ loading, messages, onReply, onPin }) => {
  const messageList = useRef();
  let messageKey = 1;

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
      {!loading && (!messages || messages.length === 0) && (
        <Empty description="No messages yet!" />
      )}
      {!loading &&
        messages &&
        messages.map((message) => (
          <MessageCard
            key={message.threadID + `${messageKey++}`}
            id={message.threadID}
            author={message.senderName}
            timeStamp={message.timeStamp}
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
