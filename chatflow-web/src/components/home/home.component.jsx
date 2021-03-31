import React from "react";
import "./App.css";
import { Layout } from "antd";
import { Sidebar } from "../side-bar/side-bar.component";
import { Headerr } from "../header/header.component";
import { ContentContainer } from "../content-container/content-container.component";
import { useParams } from "react-router-dom";

function Tmp() {
    const { id } = useParams();

    const messages = [];
    for (let i = 0; i < 100; i++) {
        messages.push(<div key={i}>{id}</div>);
    }
}

export const Home = () => (
    <div className="Home">
        <Layout style={{ minHeight: "100vh" }}>
            <Sidebar></Sidebar>
            <Layout className="site-layout">
                <Headerr prop={Tmp.id}></Headerr>
                <ContentContainer messages={Tmp.messages}></ContentContainer>
            </Layout>
        </Layout>
    </div>
);