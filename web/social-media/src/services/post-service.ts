import axios from "axios";

const API_URL = "http://localhost:5099/api/Post";

export const  fetchPosts = async (page: number = 1, pageSize: number = 2, orderBy: "latest" | "trending" = "latest") => {
  const { data } = await axios.get(`${API_URL}`, {
    params: {
      page,
      pageSize,
      orderBy
    }
  });

  return data.items; 
}
