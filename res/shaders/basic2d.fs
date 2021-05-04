#version 430

uniform sampler2D tex;
uniform float use_tex;

//layout (location = 0) in vec4 gl_FragCoord
layout (location = 1) in vec4 v_color;
layout (location = 2) in vec2 v_uv;

layout (location = 0) out vec4 frag_color;
layout (location = 1) out vec4 frag_coord;

void main() {
    frag_color = ((use_tex * texture(tex, v_uv)) + ((1.0 - use_tex) * vec4(1.0))) * v_color;
    frag_coord = gl_FragCoord;
}