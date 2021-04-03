import React from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import { NormalLoginForm } from "./components/login/login.component";
import { Home } from "./components/home/home.component";

function App() {
  return (
    <Router>
        <Switch>
          <Route path="/login">
            <NormalLoginForm />
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
