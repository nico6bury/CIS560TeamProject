import { useState, useEffect } from "react";
import "./App.css";
import styled from "styled-components";
import { Route, Switch } from "react-router";
import OriginalGeneratorPage from "./components/generatorPages/OriginalGeneratorPage";
import SpicyGeneratorPage from "./components/generatorPages/SpicyGeneratorPage";
import Header from "./components/Header";
import Sidebar from "./components/Sidebar";

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(null);
  const [userName, setUserName] = useState(null);
  return (
    <PageWrapper>
      <div>
        <Header />
        <Sidebar isLoggedIn={isLoggedIn} />
        <Switch>
          <Route exact path="/" component={OriginalGeneratorPage} />
          {isLoggedIn && (
            <Route path="/spicygenerator" component={SpicyGeneratorPage} />
          )}
        </Switch>
      </div>
    </PageWrapper>
  );
}

const PageWrapper = styled.nav`
  display: flex;
`;

export default App;
