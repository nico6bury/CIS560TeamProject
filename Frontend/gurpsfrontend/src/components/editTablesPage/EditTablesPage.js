import React from "react";
import styled from "styled-components";
import CreateTable from "./CreateTable";

export default function EditTablesPage({ userId }) {
  return (
    <PageWrapper>
      <h3>Edit/Add Tables</h3>
      <CreateTable userId={userId} />
    </PageWrapper>
  );
}

const PageWrapper = styled.nav``;
