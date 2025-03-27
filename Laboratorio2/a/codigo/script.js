function fetchData(callback) {
  setTimeout(() => {
      let data = "Data received";
      callback(data);
  }, 2000);
}

function processData(data) {
  console.log("Processing" + data);
}

fetchData(processData);