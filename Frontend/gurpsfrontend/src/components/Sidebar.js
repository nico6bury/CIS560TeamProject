import React from "react";
import { Link } from "react-router-dom";
import styled from "styled-components";

export default function Sidebar({ isLoggedIn }) {
  return (
    <PageWrapper>
      <div>
        <Link to="/">Original Generator Page</Link>
        {isLoggedIn && (
          <div>
            <Link to="/spicygenerator">Spicy Generator Page</Link>
            <Link>Table Info</Link>
            <Link>Edit/Add Tables</Link>
          </div>
        )}
      </div>
    </PageWrapper>
  );
}

const PageWrapper = styled.nav`
  display: flex;
  flex-direction: column;
`;
