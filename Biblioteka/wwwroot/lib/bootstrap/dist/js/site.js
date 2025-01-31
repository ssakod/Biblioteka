window.openFileDialog = () => {
    return new Promise((resolve, reject) => {
        const input = document.createElement("input");
        input.type = "file";
        input.onchange = (event) => {
            resolve(event.target.files[0].name);
        };
        input.click();
    });
};