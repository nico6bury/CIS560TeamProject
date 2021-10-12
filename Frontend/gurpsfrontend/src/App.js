import { useState, useEffect } from "react";
import "./App.css";
import styled from "styled-components";
import { Route, Switch } from "react-router";
import OriginalGeneratorPage from "./components/generatorPages/OriginalGeneratorPage";
import SpicyGeneratorPage from "./components/generatorPages/SpicyGeneratorPage";
import Header from "./components/Header";
import Sidebar from "./components/Sidebar";
import TableInfoPage from "./components/tableInfoPage/TableInfoPage";
import { Fragment } from "react/cjs/react.production.min";

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(true);
  const [userName, setUserName] = useState("Sarah");
  return (
    <PageWrapper>
      <div>
        <Header userName={userName} />
        <div className="contentWrapper">
          <Sidebar isLoggedIn={isLoggedIn} />
          <Switch>
            <Route exact path="/" component={OriginalGeneratorPage} />
            {isLoggedIn && (
              <Fragment>
                <Route path="/spicygenerator" component={SpicyGeneratorPage} />
                <Route path="/tableinfo" component={TableInfoPage} />
              </Fragment>
            )}
          </Switch>
        </div>
      </div>
    </PageWrapper>
  );
}

const PageWrapper = styled.nav`
  display: flex;

  .contentWrapper {
    display: flex;
    flex-direction: row;
    align-items: left;
  }
`;

export default App;
