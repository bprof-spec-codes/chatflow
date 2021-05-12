
import React, { useEffect, useState } from "react";
import 'antd/dist/antd.css';
import { Menu } from 'antd';

export const Settings = (id, roomID) => {
  const [rooms, setRoom] = useState(null);
  const axios = require("axios");
    const onClick = (values) => {
        axios
            .delete("/auth/{id}/{roomID}")
    };
  useEffect(() => {

    const minTime2 = new Promise((resolve) => setTimeout(resolve, 300));
    const req2 = axios.get(`/auth/allroom/${id}`);

    Promise.all([minTime2, req2]).then((values) => {
      const reqData2 = values[1];
      console.log(reqData2.data);
      setRoom(reqData2.data);
    }
    );
  }, [axios, setRoom, id]);


  return (
    <Menu>
      {rooms?.map(room => (
        <Menu.Item value={room.roomID} onClick=''>
          X - {room.roomName}
        </Menu.Item>
      ))}
    </Menu>
  );
};

