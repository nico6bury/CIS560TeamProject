import React, { useState, useEffect } from "react";
import styled from "styled-components";

export default function StatisticsPage({ title, data }) {
  return (
    <PageWrapper>
      <div className="displayWrapper">
        <div>{title}: &nbsp;</div>
        <div>{data}</div>
      </div>
    </PageWrapper>
  );
}

const PageWrapper = styled.nav`
  .displayWrapper {
    display: flex;
    flex-direction: row;
    border: 2px solid black;
    padding: 3px;
  }
`;
