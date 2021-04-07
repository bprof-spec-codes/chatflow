import React, { createElement, useState } from "react";
import { Comment, Tooltip, Skeleton } from "antd";
import moment from "moment";
import {
  DislikeOutlined,
  LikeOutlined,
  DislikeFilled,
  LikeFilled,
} from "@ant-design/icons";
import "./comment.styles.css";
import { ChatWindow } from "../chat-window/chat-window.component";

export const Demo = (props) => {
  const [likes, setLikes] = useState(0);
  const [dislikes, setDislikes] = useState(0);
  const [action, setAction] = useState(null);
  const { content } = props;
  const [ state, setMessagesOpen ] = useState(false);

  const like = () => {
    setLikes(1);
    setDislikes(0);
    setAction("liked");
  };

  const dislike = () => {
    setLikes(0);
    setDislikes(1);
    setAction("disliked");
  };

  const actions = [
    <Tooltip key="comment-basic-like" title="Like">
      <span onClick={like}>
        {createElement(action === "liked" ? LikeFilled : LikeOutlined)}
        <span className="comment-action">{likes}</span>
      </span>
    </Tooltip>,
    <Tooltip key="comment-basic-dislike" title="Dislike">
      <span onClick={dislike}>
        {React.createElement(
          action === "disliked" ? DislikeFilled : DislikeOutlined
        )}
        <span className="comment-action">{dislikes}</span>
      </span>
    </Tooltip>,
    <span key="comment-basic-reply-to" onClick={}>
      Reply to
    </span>,
  ];

  return (
    <div className="my-comment">
      <Skeleton
        loading={!content}
        avatar
        active
        title={false}
        paragraph={{ rows: 3 }}
      />
      {content ? (
        <Comment
          actions={actions}
          author={<p>John Doe</p>}
          content={content}
          datetime={
            <Tooltip title={moment().format("YYYY-MM-DD HH:mm:ss")}>
              <span>{moment().fromNow()}</span>
            </Tooltip>
          }
        />
      ) : (
        ""
      )}
    </div>
  );
};
