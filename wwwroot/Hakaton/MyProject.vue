<!DOCTYPE html>
<html lang="ru">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Логотип и таблица</title>
    <style>
      body {
        font-family: Arial, sans-serif;
        text-align: center;
        background-color: #fffefe;
        margin: 0;
        padding: 0;
      }

      .container {
        margin-top: 50px;
      }

      .logo {
        width: 1500px;
        height: auto;
        margin: 0 auto;
      }

      .button-container {
        margin-bottom: 20px;
      }

      button {
        background-color: #607d8b;
        color: white;
        border: none;
        border-radius: 0;
        padding: 10px 20px;
        cursor: pointer;
        transition: background-color 0.3s;
      }

      button:hover {
        background-color: red;
      }

      .modal {
        background-color: #455a64;
        color: white;
        padding: 20px;
        border-radius: 0;
      }

      .modal-header,
      .modal-footer {
        background-color: #546e7a;
        color: white;
      }

      .modal-content {
        padding: 20px;
        overflow: hidden;
      }

      .table-container {
        overflow-y: auto;
        overflow-x: auto;
        max-height: 60vh;
      }

      table {
        width: 100%;
        border-collapse: collapse;
        border: 1px solid #ddd;
        font-size: 12px;
      }

      th,
      td {
        padding: 2px;
        border: 1px solid #ddd;
        text-align: center;
        height: 15px;
        overflow: hidden;
        white-space: nowrap;
        text-overflow: ellipsis;
      }

      th {
        background-color: #607d8b;
        color: white;
        cursor: pointer;
      }

      tr:nth-child(odd) {
        background-color: white;
        color: rgb(0, 0, 0);
      }

      tr:nth-child(even) {
        background-color: #d2d2d2;
        color: rgb(0, 0, 0);
      }

      tr:hover {
        background-color: #ddd;
      }

      .close {
        cursor: pointer;
        float: right;
        margin-right: 15px;
        font-size: 18px;
      }

      .traffic-light {
        width: 10px;
        height: 10px;
        border-radius: 50%;
        display: inline-block;
      }
    </style>
  </head>
  <body>
    <div id="app">
      <div class="container">
        <img
          src="pTQELsN3_1727464554.png"
          alt="Логотип компании"
          class="logo"
        />
        <div class="button-container">
          <button @click="exportToExcel">Экспорт</button>
          <button @click="groupingOptions">Группировка</button>
          <button @click="searchProjects">Поиск</button>
          <button @click="resetToDefault">Домик</button>
          <button @click="showGeneralInfo">Общая информация</button>
          <button @click="showProjectStatus">Состояние</button>
          <button @click="showProjectTeam">Команда проекта</button>
          <button @click="showProjectTimeline">Сроки</button>
          <button @click="goBack">Назад</button>
        </div>
      </div>

      <div v-if="modalVisible" class="modal">
        <div class="modal-header">
          <span class="close" @click="closeModal">&times;</span>
          <h2>Таблица данных</h2>
        </div>
        <div class="modal-content">
          <div class="table-container">
            <table id="excelTable">
              <thead>
                <tr>
                  <th v-for="(header, index) in headers" :key="index">
                    {{ header }}
                  </th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="(row, rowIndex) in displayedData" :key="rowIndex">
                  <td v-for="(cell, cellIndex) in row" :key="cellIndex">
                    {{ cell === undefined ? "" : cell }}
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/vue@2"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/xlsx/0.17.0/xlsx.full.min.js"></script>
    <script>
      new Vue({
        el: "#app",
        data: {
          jsonData: [],
          originalData: [],
          headers: [],
          displayedData: [],
          modalVisible: false,
        },
        methods: {
          goBack() {
            window.history.back();
          },
          async loadExcelFromUrl(url) {
            try {
              const response = await fetch(url);
              const data = await response.arrayBuffer();
              const workbook = XLSX.read(data, { type: "array" });
              const firstSheetName = workbook.SheetNames[0];
              const worksheet = workbook.Sheets[firstSheetName];

              this.jsonData = XLSX.utils.sheet_to_json(worksheet, {
                header: 1,
              });
              this.originalData = this.jsonData.slice();
              this.headers = this.jsonData[1]; // Заголовки во второй строке
              this.displayedData = this.jsonData.slice(2); // Данные, начиная с третьей строки
              this.openModal();
            } catch (error) {
              console.error("Ошибка при загрузке Excel файла:", error);
            }
          },
          openModal() {
            this.modalVisible = true;
          },
          closeModal() {
            this.modalVisible = false;
          },
          updateTable(data) {
            this.displayedData = data;
          },
          exportToExcel() {
            alert("Экспорт в Excel будет реализован в будущем."); // Заглушка для экспорта
          },
          groupingOptions() {
            const criteria = prompt(
              "Введите критерий для группировки (например: Предпроект, Реализация):"
            );
            if (criteria) {
              this.groupProjects(criteria);
            }
          },
          groupProjects(criteria) {
            const keywords = criteria.split(",").map((word) => word.trim());
            const matchedRows = [];

            this.jsonData.slice(3).forEach((row) => {
              const rowString = row.join(" ");
              const matchCount = keywords.reduce(
                (count, keyword) =>
                  count + (rowString.includes(keyword) ? 1 : 0),
                0
              );
              if (matchCount > 0) {
                matchedRows.push(row);
              }
            });

            this.updateTable(
              matchedRows.concat(
                this.jsonData
                  .slice(3)
                  .filter((row) => !matchedRows.includes(row))
              )
            );
            this.openModal();
          },
          searchProjects() {
            const searchTerm = prompt("Введите текст для поиска:");
            if (searchTerm) {
              const matchedRows = this.jsonData.filter((row) =>
                row.some((cell) =>
                  cell
                    .toString()
                    .toLowerCase()
                    .includes(searchTerm.toLowerCase())
                )
              );
              this.updateTable(matchedRows);
              this.openModal();
            }
          },
          resetToDefault() {
            this.updateTable(this.originalData.slice(2));
          },
          showGeneralInfo() {
            const headerIndexes = [0, 1, 2, 3]; // Индексы нужных столбцов
            const filteredData = this.jsonData
              .slice(3)
              .map((row) => headerIndexes.map((index) => row[index]));
            this.updateTable(filteredData);
            this.openModal();
          },
          showProjectStatus() {
            const headerIndexes = [0, 1, 2, 3, 4]; // Индексы нужных столбцов
            const filteredData = this.jsonData
              .slice(3)
              .map((row) => headerIndexes.map((index) => row[index]));
            this.updateTable(filteredData);
            this.openModal();
          },
          showProjectTeam() {
            const headerIndexes = [2, 3, 4, 21, 23, 24, 25]; // Индексы нужных столбцов
            const filteredData = this.jsonData
              .slice(3)
              .map((row) => headerIndexes.map((index) => row[index]));
            this.updateTable(filteredData);
            this.openModal();
          },
          showProjectTimeline() {
            const headerIndexes = [2, 3, 4, 38, 39, 40, 41, 42, 43]; // Индексы нужных столбцов
            const filteredData = this.jsonData
              .slice(3)
              .map((row) => headerIndexes.map((index) => row[index]));
            this.updateTable(filteredData);
            this.openModal();
          },
        },
        mounted() {
          this.loadExcelFromUrl("Пример базового файла.xlsx"); // Путь к вашему файлу
        },
      });
    </script>
  </body>
</html>
