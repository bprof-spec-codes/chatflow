import React from "react";
import "./home.styles.css";
import { Layout } from "antd";
import { Sidebar } from "../side-bar/side-bar.component";
import { TopRow } from "../header/header.component";
import { ContentContainer } from "../content-container/content-container.component";
import { useParams } from "react-router-dom";

// function Tmp() {
//     const { id } = useParams();

//     const messages = [];
//     for (let i = 0; i < 100; i++) {
//         messages.push(<div key={i}>{id}</div>);
//     }
// }

export const Home = () => (
    <div className="Home">
        <Layout style={{ minHeight: "100vh" }}>
            <Sidebar></Sidebar>
            <Layout className="site-layout">
                <TopRow></TopRow>
                <ContentContainer></ContentContainer>
            </Layout>
        </Layout>
    </div>
);