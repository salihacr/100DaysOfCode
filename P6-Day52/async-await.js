// async await
async function fetchPosts() {
    const response = await fetch("https://jsonplaceholder.typicode.com/posts")
    const data = await response.json();
    console.log(response);
    data.forEach(i => {
        console.log("i", i);
    });
}
fetchPosts();