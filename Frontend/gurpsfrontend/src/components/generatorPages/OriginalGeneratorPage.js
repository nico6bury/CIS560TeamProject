import React, { useState, useEffect } from "react";
import styled from "styled-components";
import GenerateBox from "./GenerateBox";
import Filters from "./Filters";

let fakeICD = [
  {
    name: "Fibers and Fabrics",
    itemCategoryId: 1,
    checked: true,
  },
  {
    name: "Spices",
    itemCategoryId: 2,
    checked: true,
  },
  {
    name: "Jewelry",
    itemCategoryId: 3,
    checked: false,
  },
];

let declaredExtrasData = [
  {
    name: "Embelishments",
    id: 1,
    checked: true,
  },
  {
    name: "Enchantments",
    id: 2,
    checkd: true,
  },
];

export default function OriginalGeneratorPage() {
  const [itemCategoryData, setItemCategoryData] = useState(fakeICD);
  const [extrasData, setExtrasData] = useState(declaredExtrasData);

  useEffect(() => {
    //fetch the necessary data for the filters
  });

  return (
    <PageWrapper>
      <h1>Original GURPS Generator</h1>
      <div className="pageContent">
        <GenerateBox typeBox="Original" tables="Default" />
        <div className="spacer1" />
        <Filters
          itemCategoryData={itemCategoryData}
          setItemCategoryData={setItemCategoryData}
          extrasData={extrasData}
          setExtrasData={setExtrasData}
          isSpicy={true}
        ></Filters>
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
  .spacer1 {
    margin-right: 100px;
  }
`;
