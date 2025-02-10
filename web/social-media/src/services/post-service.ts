import axios from "axios";

const API_URL = "http://localhost:5099/api/Post";

export async function fetchPosts(
  orderBy: "latest" | "trending",
  keyword: string,
  pageParam: number = 1
) {
  const pageSize = pageParam === 1 ? 15 : 20;
  const { data } = await axios.get(
    `${API_URL}?page=${pageParam}&pageSize=${pageSize}&orderBy=${orderBy}&keyword=${keyword}`
  );

  return {
    posts: data.items,
    nextPage: data.items.length === pageSize ? pageParam + 1 : null,
  };
}
