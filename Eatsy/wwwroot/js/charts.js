let instances = {};

window.initBarChart = (id, labels, data) => {
    initChart(id, 'bar', labels, data, 'Calories', ['#FF6384', '#36A2EB', '#FFCE56', '#4BC0C0', '#9966FF', '#FF9F40', '#E7E9ED', '#8AC926']);
};

window.initPieChart = (id, labels, data) => {
    initChart(id, 'pie', labels, data, 'Recettes', ['#FF6384', '#36A2EB', '#FFCE56', '#4BC0C0', '#9966FF', '#FF9F40']);
};

window.initDonutChart = (id, labels, data) => {
    initChart(id, 'doughnut', labels, data, 'Cuisines', ['#36A2EB', '#FFCE56', '#FF6384', '#4BC0C0', '#9966FF', '#FF9F40']);
};

function initChart(id, type, labels, data, label, colors) {
    const ctx = document.getElementById(id);
    if (!ctx) return;

    if (instances[id]) {
        instances[id].destroy();
    }

    instances[id] = new Chart(ctx, {
        type: type,
        data: {
            labels: labels,
            datasets: [{
                label: label,
                data: data,
                backgroundColor: colors,
                borderColor: '#fff',
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    position: type === 'bar' ? 'none' : 'right'
                }
            }
        }
    });
}
