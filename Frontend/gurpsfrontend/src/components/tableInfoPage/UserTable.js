import React, { useState, useEffect } from "react";
import styled from "styled-components";
import { useTable, useSortBy } from "react-table";

export default function UserTable({ data }) {
  const [isLoaded, setIsLoaded] = useState("");

  const columns = React.useMemo(
    () => [
      {
        Header: "Item",
        accessor: "name",
      },
      {
        Header: "Base Price",
        accessor: "unitPrice",
      },
      {
        Header: "Base Weight",
        accessor: "baseWeight",
      },
      {
        Header: "Weight Type",
        accessor: "weightType",
      },
      {
        Header: "Quantity Min",
        accessor: "quantityMin",
      },
      {
        Header: "Quantity Max",
        accessor: "quantityMax",
      },
      {
        Header: "Description",
        accessor: "description",
      },
      {
        Header: "Relative Chance",
        accessor: "relativeChance",
      },
    ],
    []
  );

  const { getTableProps, getTableBodyProps, headerGroups, rows, prepareRow } =
    useTable(
      {
        columns,
        data: data,
      },
      useSortBy
    );

  const handleRowClick = (e) => {
    //do something
  };

  return (
    <PageWrapper>
      <div>
        <form className="generate-form">
          <table {...getTableProps()}>
            <thead>
              {headerGroups.map((headerGroup) => (
                <tr {...headerGroup.getHeaderGroupProps()}>
                  {headerGroup.headers.map((column) => (
                    <th
                      {...column.getHeaderProps(column.getSortByToggleProps())}
                    >
                      {column.render("Header")}
                      <span>
                        {column.isSorted
                          ? column.isSortedDesc
                            ? "▼"
                            : "▲"
                          : " ▲▼"}
                      </span>
                    </th>
                  ))}
                </tr>
              ))}
            </thead>
            <tbody {...getTableBodyProps()}>
              {rows.map((row, i) => {
                prepareRow(row);
                return (
                  <tr
                    {...row.getRowProps()}
                    key={i}
                    onClick={() => handleRowClick(row)}
                  >
                    {row.cells.map((cell) => {
                      return (
                        <td {...cell.getCellProps()}>{cell.render("Cell")}</td>
                      );
                    })}
                  </tr>
                );
              })}
            </tbody>
          </table>

          {isLoaded === "error" && (
            <div className="errorMessage wrapText">Something went wrong.</div>
          )}
        </form>
      </div>
    </PageWrapper>
  );
}

const PageWrapper = styled.nav`
  display: flex;
  flex-direction: column;
  max-width: 900px;
  .wrapText {
    max-width: 350px;
    word-wrap: break-word;
  }

  .generateWrapper {
    display: flex;
    flex-direction: row;
    margin-top: 15px;
  }
  .generate-form {
    display: flex;
    flex-direction: column;
    margin-bottom: 3px;
  }
  .textBox {
    margin-bottom: 5px;
  }
  table {
    border-spacing: 0;
    border: 1px solid black;

    tr {
      :last-child {
        td {
          border-bottom: 0;
        }
      }
    }
    tr:hover {
      th {
        background: var(--mainWhite);
      }
      background: var(--lightGrey);
    }

    th,
    td {
      margin: 0;
      padding: 0.15rem 0.15rem 0.15rem 0.35rem;
      border-bottom: 1px solid black;
      border-right: 1px solid black;

      :last-child {
        border-right: 0;
      }
    }
  }
`;
