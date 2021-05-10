import React from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import { NormalLoginForm } from "./components/login/login.component";
import { AddUser } from "./components/admin-components/add-user/add-user.component";
import { ModifyUser } from "./components/admin-components/Modify-user/modify-user.component";
import { Home } from "./components/home/home.component";
import AdminLayout from "./components/admin-components/admin-layout/admin-layout.component";

function App() {
  return (
    <Router>
        <Switch>
          <Route path="/login">
            <NormalLoginForm />
          </Route>
          <Route path="/add">
            <AddUser />
          </Route>
          <Route path="/modify">
            <ModifyUser />
          </Route>
          <Route path="/admin">
            <AdminLayout />
          </Route>
          <Route path="/rooms/:id">
            <Home />
          </Route>
          <Route path="/">
            <Home />
          </Route>
        </Switch>
    </Router>
  );
}

export default App;
