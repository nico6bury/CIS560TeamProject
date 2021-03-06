import React, { useState, useEffect } from "react";
import styled from "styled-components";
import { useTable, useSortBy } from "react-table";

let fakeData = [
  {
    item: "AnItem",
    embelishments: "fire",
    price: "$30.50",
  },
  {
    item: "AnotherItem",
    embelishments: "none",
    price: "$0.70",
  },
  {
    item: "LastItem",
    embelishments: "ice",
    price: "$100000.90",
  },
];
export default function GenerateBox({
  typeBox,
  originalData,
  spicyData,
  userId,
}) {
  const [nextGenerated, setNextGenerated] = useState("");
  const [counter, setCounter] = useState(0);
  const [isLoaded, setIsLoaded] = useState("");
  const [randResult, setRandResult] = useState([]);
  const [numberGenerate, setNumberGenerate] = useState(1);

  const handleClick = (e) => {
    e.preventDefault();
    //setCounter(counter + 1);
    //setNextGenerated(counter);

    //Checking if the number to generate is a valid number to enter
    if (numberGenerate.length < 1 || parseInt(numberGenerate) > 20) {
      setIsLoaded("invalid");
      return;
    }

    //Looping through the data to determine what tables to include
    let tables = [];
    originalData.map((item) => {
      if (item.checked === true) {
        tables.push(item);
      }
    });
    // spicyData.map((item) => {
    //   if (item.checked === true) {
    //     tables.push(item);
    //   }
    // });

    setIsLoaded("okay");
    doFetch(tables);
    //setRandResult(fakeData);
  };

  const doFetch = (tablesToInclude) => {
    let typeGen = -2;
    if (typeBox === "Spicy") {
      typeGen = -1;
    }

    let send = JSON.stringify({
      NumItems: numberGenerate,
      UserId: userId,
      TypeGenerate: -1,
    });
    fetch(`http://localhost:5000/api/RandomItem/${send}`, {
      method: "get",
      headers: {
        //"Content-Type": "application/json",
        //"Access-Control-Allow-Credentials": true,
      },
      //credentials: "include",
    })
      .then((res) => res.json())
      .then(
        (result) => {
          console.log(result);
          setRandResult(result);
          setIsLoaded("loaded");
        },
        // Note: it's important to handle errors here
        // instead of a catch() block so that we don't swallow
        // exceptions from actual bugs in components.
        (error) => {
          setIsLoaded("error");
          //console.log(error);
        }
      );
  };

  const columns = React.useMemo(
    () => [
      {
        Header: "Item",
        accessor: "name",
      },
      {
        Header: "Weight",
        accessor: "baseWeight",
      },
      {
        Header: "Weight Type",
        accessor: "weightType",
      },
      {
        Header: "Price",
        accessor: "unitPrice",
      },
      {
        Header: "Description",
        accessor: "description",
      },
      {
        Header: "Quantity Min",
        accessor: "quantityMin",
      },
      {
        Header: "Quantity Max",
        accessor: "quantityMax",
      },
    ],
    []
  );

  const { getTableProps, getTableBodyProps, headerGroups, rows, prepareRow } =
    useTable(
      {
        columns,
        data: randResult,
      },
      useSortBy
    );

  const handleRowClick = (e) => {
    //do something
  };

  const handleNumberChange = (e) => {
    if (Number(e.target.value) || e.target.value === "") {
      setNumberGenerate(e.target.value);
    }
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
                            ? "???"
                            : "???"
                          : " ??????"}
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
          <div className="generateWrapper">
            <input
              readOnly={false}
              value={numberGenerate}
              className="textBox"
              onChange={handleNumberChange}
            />
            <button className="mainBtn" onClick={handleClick}>
              Generate!
            </button>
          </div>
          {isLoaded === "invalid" && (
            <div className="errorMessage wrapText">
              Invalid Number to Generate. Please enter a number between 1-20.
            </div>
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
