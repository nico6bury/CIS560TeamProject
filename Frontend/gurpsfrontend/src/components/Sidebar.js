import React, { useEffect, useState } from "react";
import styled from "styled-components";
import { Link, useLocation } from "react-router-dom";

export default function Sidebar({ isLoggedIn }) {
  // return (
  //   <PageWrapper>
  //     <div>
  //       <Link to="/">Original Generator Page</Link>
  //       {isLoggedIn && (
  //         <div>
  //           <Link to="/spicygenerator">Spicy Generator Page</Link>
  //           <Link>Table Info</Link>
  //           <Link>Edit/Add Tables</Link>
  //         </div>
  //       )}
  //     </div>
  //   </PageWrapper>
  // );

  const location = useLocation();
  //var to get the current page the user is on for highlighting that page
  //on the navbar
  let pageName = location.pathname.replaceAll("/", "");
  const [homeLit, setHomeLit] = useState(false);
  const [registerLit, setRegisterLit] = useState(false);
  //the current page the user is on. If they're on the homepage, replace
  //the empty string with "home", otherwise use 'pageName'
  const [currentPage, setCurrentPage] = useState(
    pageName === "" ? "home" : pageName
  );

  return (
    <SideWrapper>
      <ul>
        <li key={1}>
          <Link
            to="/"
            className={
              "sidebar-link " + (currentPage === "home" ? "lit" : "unlit")
            }
            id="homeLink"
            onClick={() => setCurrentPage("home")}
          >
            Original Generator
          </Link>

          {isLoggedIn && (
            <div>
              <Link
                to="/spicygenerator"
                className={
                  "sidebar-link " +
                  (currentPage.includes("spicy") ? "lit" : "unlit")
                }
                id="spicyGeneratorLink"
                onClick={() => setCurrentPage("spicygenerator")}
              >
                Spicy Generator
              </Link>
              <Link
                to="/tableinfo"
                className={
                  "sidebar-link " +
                  (currentPage === "tableinfo" ? "lit" : "unlit")
                }
                id="tableInfoLink"
                onClick={() => setCurrentPage("tableinfo")}
              >
                Table Info
              </Link>
            </div>
          )}
        </li>
      </ul>
    </SideWrapper>
  );
}

const SideWrapper = styled.nav`
  //position:fixed;
  //top:200px;
  //left:50px;
  //width: 60px;
  height: 180px;
  background: var(--mainGrey);
  //z-index:1;
  //border-right:4px solid var(--primaryColor);
  //border-bottom:4px solid var(--primaryColor);
  //border-left:4px solid var(--primaryColor);
  //border-top:4px solid var(--primaryColor);
  transition: var(--mainTransition);
  font-size: 20px !important;

  margin: 10px;
  ul {
    list-style-type: none;
    padding: 0 !important;
  }
  .sidebar-link {
    display: block;
    //font-size: 1.5rem;
    text-transform: capitalize;
    padding: 0.5rem 1rem;
    font-size: 20px;
    transition: var(--mainTransition);
    text-decoration: none;
    width: 80%;
  }
  .sidebar-link:hover {
    background: #9b9b9b;
    color: var(--mainWhite);
    padding: 0.5rem 1.5rem 0.5rem 2.5rem;
    text-decoration: none;
  }
  .lit {
    color: var(--mainWhite);
    background: var(--primaryOrangeColor);
  }
  .unlit {
    color: var(--mainBlack);
    background: var(--lightGrey);
  }
  @media (min-width: 576px) {
    width: 20rem;
  }
`;
