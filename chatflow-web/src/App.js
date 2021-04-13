import React from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import { NormalLoginForm } from "./components/login/login.component";
import { Home } from "./components/home/home.component";
import AdminUI from "./components/admin-components/admin-ui/admin-ui.component";

function App() {
  return (
    <Router>
        <Switch>
          <Route path="/login">
            <NormalLoginForm />
          </Route>
          <Route path="/admin">
            <AdminUI />
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
