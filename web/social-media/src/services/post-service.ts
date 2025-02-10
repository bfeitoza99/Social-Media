import axios from "axios";

const API_URL = "http://localhost:5099/api/Post";

export async function fetchPosts({ pageParam = 1 }) {
  const pageSize = pageParam === 1 ? 15 : 20;
  const response = await axios.get(API_URL, {
    params: {
      page: pageParam,
      pageSize,
      orderBy: "latest",
    },
  });

  const data = response.data;

  return {
    posts: data.items,
    nextPage: data.items.length === pageSize ? pageParam + 1 : null,
  };
}
