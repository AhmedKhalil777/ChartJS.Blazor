export function createChart(id, configs) {
    var myChart = new Chart(
        document.getElementById(id),
        configs
    );
}