window.DownloadFileFromStream = async (_file_name, _stream_ref) => {
    const array_buffer = await _stream_ref.arrayBuffer();
    const blob = new Blob([array_buffer]);
    const url = URL.createObjectURL(blob);
    const anchor_element = document.createElement('a');
    anchor_element.href = url;
    anchor_element.download = _file_name ?? '';
    anchor_element.click();
    anchor_element.remove();
    URL.revokeObjectURL(url);
}
