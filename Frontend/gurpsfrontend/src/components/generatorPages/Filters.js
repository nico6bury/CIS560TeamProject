import React from "react";
import styled from "styled-components";
import ExtrasCheckboxes from "./FilterSections/ExtrasCheckboxes";
import FilterCheckboxes from "./FilterSections/FilterCheckboxes";

export default function Filter({
  itemCategoryData,
  setItemCategoryData,
  extrasData,
  setExtrasData,
  isSpicy,
  userTables,
  setUserTables,
}) {
  return (
    <PageWrapper>
      <div>
        <div className="filtersHeader">Filters</div>
        <div className="sectionHeader">General Filters</div>
        <FilterCheckboxes data={extrasData} setData={setExtrasData} />
        <div className="sectionHeader">Item Category Filters</div>
        <FilterCheckboxes
          data={itemCategoryData}
          setData={setItemCategoryData}
        />
        {isSpicy && (
          <div>
            <div className="sectionHeader">User-Defined Categories</div>
            <FilterCheckboxes data={userTables} setData={setUserTables} />
          </div>
        )}
      </div>
    </PageWrapper>
  );
}

const PageWrapper = styled.nav`
  display: flex;
  flex-direction: column;
  border: 3px solid black;
  .filtersHeader {
    font-size: 2rem;
  }
  .sectionHeader {
    font-size: 1.5rem;
  }
`;
