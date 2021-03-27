import React, { createElement, useState } from "react";
import { Comment, Tooltip, Avatar } from "antd";
import moment from "moment";
import {
  DislikeOutlined,
  LikeOutlined,
  DislikeFilled,
  LikeFilled,
} from "@ant-design/icons";
import "./comment.styles.css";

export const Demo = () => {
  const [likes, setLikes] = useState(0);
  const [dislikes, setDislikes] = useState(0);
  const [action, setAction] = useState(null);

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
    <span key="comment-basic-reply-to">Reply to</span>,
  ];

  return (
    <Comment
      actions={actions}
      author={<p>John Doe</p>}
      /*avatar={
        <Avatar
          src="https://zos.alipayobjects.com/rmsportal/ODTLcjxAfvqbxHnVXCYX.png"
          alt="Han Solo"
        />
      }*/
      content={
        <p>
          Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec rutrum
          feugiat libero porttitor lacinia. Praesent dui nunc, dapibus eget
          cursus et, dictum quis felis. Ut euismod libero nunc, a tincidunt
          ligula faucibus et.
          Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec rutrum
          feugiat libero porttitor lacinia. Praesent dui nunc, dapibus eget
          cursus et, dictum quis felis. Ut euismod libero nunc, a tincidunt
          ligula faucibus et.
          Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec rutrum
          feugiat libero porttitor lacinia. Praesent dui nunc, dapibus eget
          cursus et, dictum quis felis. Ut euismod libero nunc, a tincidunt
          ligula faucibus et.
        </p>
      }
      datetime={
        <Tooltip title={moment().format("YYYY-MM-DD HH:mm:ss")}>
          <span>{moment().fromNow()}</span>
        </Tooltip>
      }
    />
  );
};
