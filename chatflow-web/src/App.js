import React from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import { NormalLoginForm } from "./components/login/login.component";
import { Home } from "./components/home/home.component";

function App() {
  return (
    <Router>
        {/* A <Switch> looks through its children <Route>s and
            renders the first one that matches the current URL. */}
        <Switch>
          <Route path="/login">
            <NormalLoginForm />
          </Route>
          <Route path="/home">
            <Home />
          </Route>
          <Route path="/">
            <NormalLoginForm />
          </Route>
        </Switch>
    </Router>
  );
}

export default App;
