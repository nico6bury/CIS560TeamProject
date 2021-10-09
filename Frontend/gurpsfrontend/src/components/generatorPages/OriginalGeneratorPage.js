import React, { useState } from "react";
import styled from "styled-components";
import GenerateBox from "./GenerateBox";

export default function OriginalGeneratorPage() {
  return (
    <PageWrapper>
      <h1>Original GURPS Generator</h1>
      <div className="pageContent">
        <GenerateBox typeBox="Original" tables="Default" />
      </div>
    </PageWrapper>
  );
}

const PageWrapper = styled.nav`
  display: flex;
  flex-direction: column;

  .pageContent {
    display: flex;
    flex-direction: row;
  }
`;
