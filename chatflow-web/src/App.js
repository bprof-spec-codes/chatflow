import React from "react";
import "./App.css";
import { Layout } from "antd";
import { Sidebar } from "./components/side-bar/side-bar.component";

function App() {
  return (
    <div className="App">
      <Layout style={{ minHeight: "100vh", width: "100vw" }}>
        <Sidebar></Sidebar>
      </Layout>
    </div>
  );
}

export default App;
