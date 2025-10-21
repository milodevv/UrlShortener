async function copyContent(text) {
    try {
        await navigator.clipboard.writeText(text);
        console.log('Contenido copiado al portapapeles');
    } catch (err) {
        console.error('Error al copiar: ', err);
    }
}